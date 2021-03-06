import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class Home extends Component {
  displayName = Home.name

  render() {
    return (
        <div>
            <h1 className="appHeader">Compass Surveys!</h1>
            <p>Welcome to compass surveys, built with:</p>
                <ul>
                    <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
                    <li><a href='https://facebook.github.io/react/'>React</a> for client-side code</li>
                    <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>
                </ul>
            <p>To view the list of surveys, click here:</p>
                <ul>
                    <Link to="/surveys">    
                        <li><strong>Survey List</strong></li>
                    </Link>
                </ul>            
        </div>
    );
  }
}
