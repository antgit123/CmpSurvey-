import React, { Component } from 'react';
import { Route } from 'react-router';
import { Home } from './components/Home';
import { ViewSurvey } from './components/ViewSurvey';
import { ViewSurveyDetail } from './components/ViewSurveyDetail';
import { SurveyLayout } from './components/SurveyLayout';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <SurveyLayout>            
            <Route exact path='/' component={Home} />      
            <Route exact path='/surveys' component={ViewSurvey} />
            <Route path='/surveys/:id' component={ViewSurveyDetail} />
        </SurveyLayout>
    );
  }
}
