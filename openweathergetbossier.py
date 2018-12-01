import datetime
import json
import urllib.request

def url_builder():
    user_api = '' #an open weathermap api key needs to be entered here
    unit = 'imperial'
    api = 'http://api.openweathermap.org/data/2.5/weather?id=4317639' #bossier city

    full_api_url = api + '&mode=json&units=' + unit + '&APPID=' + user_api
    return full_api_url


def data_fetch(full_api_url):
    url = urllib.request.urlopen(full_api_url)
    output = url.read().decode('utf-8')
    raw_api_dict = json.loads(output)
    url.close()
    return raw_api_dict


def data_organizer(raw_api_dict):
    data = dict(
        temp=raw_api_dict.get('main').get('temp'),
        humidity=raw_api_dict.get('main').get('humidity'),
        pressure=raw_api_dict.get('main').get('pressure'),
    )
    return data


if __name__ == '__main__':
    data = data_organizer(data_fetch(url_builder()))
    
    body = {
    'pressure': data['pressure'],
    'humidity': data['humidity'],
    'temperature': data['temp'],
    'date': datetime.datetime.now().isoformat(),
    'sourceid': 3 } #sourceid assigned to openweather - bossier city

    myurl = "/api/record" #the full address of the backend api needs to be added here
    req = urllib.request.Request(myurl)
    req.add_header('Content-Type', 'application/json; charset=utf-8')
    jsondata = json.dumps(body)
    jsondataasbytes = jsondata.encode('utf-8')   # needs to be bytes
    req.add_header('Content-Length', len(jsondataasbytes))
    response = urllib.request.urlopen(req, jsondataasbytes)
