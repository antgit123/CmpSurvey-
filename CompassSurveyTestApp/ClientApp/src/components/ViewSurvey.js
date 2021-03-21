import React, { Component } from 'react';
import { Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { FeedbackScreenComponent } from './FeedbackScreenComponent';

export class ViewSurvey extends Component {
    
    loadSurveyData = () => {         
        fetch('api/Surveys')
            .then(response => response.json())
            .then(data => {
                this.setState({ surveyData: data, loading: false });
            });  
    }

    onSelectSurvey = (survey) => {
        this.setState({ selectedSurvey: survey });
    }
    constructor(props) {
        super(props);
        this.state = { surveyData: [], selectedSurvey: null, loading: true };   
    }

    componentDidMount() {
        this.loadSurveyData();          
    }
    render() {
        const { loading, surveyData } = this.state;
        //Show feedback screen to the user if the fetching of surveys hasn't completed
        if (loading) {           
           return( 
               <FeedbackScreenComponent
                    message={`Survey Data loading...`}
                    loading={true}                    
                />
            )
        }
        // check data after it is returned, If no surveys found display feedback to the user with the option to navigate back
        if (!loading && (!surveyData.surveys || surveyData.surveys.length === 0)) {            
            return (
                <FeedbackScreenComponent
                    message={`Sorry, there is no list of surveys. Please check back later`}                    
                    loading={false}
                    backButtonUrl={`/`}
                />
            )
        }
        //Display list of surveys to the user if the above prerequisites are satisfied 
        return (
            <div>
                <h3 className="appHeader"> Compass Surveys </h3>
                {surveyData.surveys.map((survey) => (
                    <Link to={{
                        pathname: `/surveys/${survey.id}`,
                        state: {
                            selectedSurvey: survey
                        }
                    }}>
                        <Button className="surveyButton" key={survey.id} variant="primary" size="lg" block onClick={this.onSelectSurvey.bind(this, survey)}>{survey.name}</Button>
                    </Link>
                ))}
            </div>    
        );
    }
}