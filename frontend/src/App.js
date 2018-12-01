import React, { Component } from 'react';
import './App.css';
import Chart from './Components/Chart';


class App extends Component {
  constructor(){
    super();
    this.state = {
      chartData:null
    }
  }

  componentDidMount(){
    this.getChartData();
  }

  getChartData(){
    // Ajax calls here
      fetch(`/api/records/12`) //the full api url needs to be added here
      .then(res => res.json())
      .then(data => {this.setState({
      chartData:{
        labels: data.names,
        datasets:[
          {
            label:'Temperature',
            data:data.data,
            backgroundColor:
              'rgba(255, 99, 132, 0.6)'
            
          }
        ]
      }
    });});
    
  }

  render() {
    
         if(this.state.chartData != null){
      return (
        <Chart chartData={this.state.chartData} location="Ken's Study" legendPosition="bottom"/>
      
        );
  }
         
      return <div>Loading </div> 
    
    
  }
    

/*class App extends Component{

    
   componentDidMount() {
    fetch(`http://www.kurtgehl.com/api/test`)
      .then(res => res.json())
      .then(json => this.setState({ data: json }));
  }
    render() {
        return(
            
                <Graph />
           
        )
    }
    
*/
    
    
}









     




export default App;