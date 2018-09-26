import React, { Component } from "react";
import "./App.css";
import Jobs from './Jobs';

class App extends Component {
  

  render() {
    return (
      
      <div className="App">
      <div className="App-header"> Job Adder
      </div>
        <div className="App-intro">
         <Jobs />
        </div>
      </div>
    );
  }
}

export default App;
