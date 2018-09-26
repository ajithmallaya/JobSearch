import React, { Component } from "react";
import "./App.css";
import axios from 'axios';
import {getAppDataById} from './helpers/appDataUtil';

class Jobs extends Component {
  constructor(props) {
    super(props);

    this.state = {
      jobs: [],
    };
  }  

  FetchJobs(roles,searchkey) {
    var that = this;
    axios.get('http://localhost:3000/Jobs/' + roles + '/' + searchkey).then(function (result) {
     console.log(result.data.result.JobWithCandidates);
      that.setState({ jobs: result.data.result.JobWithCandidates });
    });
  }   

  render() {
    return (
      <React.Fragment>
        <span className="jobs job-header"> Search Jobs </span>
        <div className="input-section">
            <div> <span>Roles: <input id="searchInputRolesText" type="text"></input> </span>
             <span>Skills: <input id="searchInputSkillsText" type="text"></input></span>
            <button onClick={ () => this.FetchJobs(getAppDataById("searchInputRolesText"),getAppDataById("searchInputSkillsText"))}> Search </button>
            </div>
            
            
        </div>
        {
		  this.state.jobs.length > 0 && 
          <div className="jobs__item">
             <div className="jobs">
			 
                 <div className="flex job-header">
                   <div className="col-3">Job</div>
                   <div className="col-3">Candidates</div>
                 </div>
                 
                {
                  this.state.jobs.map((items, index) =>
                    <div key={`${items}${index}`} className="jobs-section">
                        <div className="flex">
                          <div className="jobs col-3">
                          <span className="text">
                           <span className="label-header"> Name: </span>
                            {items.Name} </span>
                            <span className="text"> 
                            <span className="label-header">Company: </span>
                            {items.Company}  </span>
                            <span className="text">
                            <span className="label-header">Required Skills:</span>
                            {items.Skills} </span>
                          </div>
                          <div className="candidates col-3">
                            {items.Candidates.map((candidate, index) =>
                            <div key={`${candidate}${index}`} className="candidates-section">
                              <div className="flex">
                              <div className="jobs col-3">
                              <span className="text">
                              <span className="label-header">Name: </span>
                               {candidate.Name} </span>
                              <span className="text">
                              <span className="label-header"> Skills declared: </span>
                              {candidate.SkillTags} </span>
                              </div>
                              </div>
                             </div>
                          
                          )}
                        </div>
                  </div>
                  </div>
                )
              }
              </div>
            </div>
	  	}
      </React.Fragment>
    );
  }
}

export default Jobs;