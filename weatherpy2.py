import datetime
import urllib2
import json


pressure = 800
temp = 60
humidity = 20

body = {
'pressure': pressure,
'humidity': humidity,
'temperature': temp,
'date': datetime.datetime.now().isoformat(),
'sourceid': 1 } #sourceid assigned to ken's pi

myurl = "/api/record" #the full url of the backend api needs to be added here
req = urllib2.Request(myurl)
req.add_header('Content-Type', 'application/json; charset=utf-8')
jsondata = json.dumps(body)
jsondataasbytes = jsondata.encode('utf-8')   # needs to be bytes
req.add_header('Content-Length', len(jsondataasbytes))
response = urllib2.urlopen(req, jsondataasbytes)

