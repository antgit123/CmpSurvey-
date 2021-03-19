import React, { Component } from 'react';
import QuestionComponent from './QuestionComponent';
import { Form, Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';

 export class ViewSurveyDetail extends Component {

    constructor(props) {
        super(props);  
        this.state = { surveyQuestionData: [], loading: true };
        const { selectedSurvey } = this.props.location.state;
        // API call to fetch questions from the selected survey 
        fetch('api/Surveys/' + selectedSurvey.id)
            .then(response => response.json())
            .then(data => {
                this.setState({ surveyQuestionData: data, survey: selectedSurvey, loading: false });
            });  
    }

     render() {         
         //If survey questions are loading show this screen to the user to indicate that application is loading
         if (this.state.loading) {
             return (
                 <div> Survey Questions Loading...</div>
             )
         }
         // check data after it is returned, If no questions found display feedback to the user else show screen with all questions
         const surveyQuestions = this.state.surveyQuestionData;
         const hasNoQuestions = !surveyQuestions || surveyQuestions.length === 0;
         if (!this.state.loading && hasNoQuestions) {
             return (
                 <div> Sorry no questions found in the survey. Please choose another survey
                     <Link to="/surveys">
                         <Button variant="primary">Back</Button>
                     </Link>
                 </div>
             )
         }
         //load all questions from the survey if above preconditions are satisfied 
         return (
             <div>
                 <h3 className="appHeader">{this.state.survey.name}</h3>
                    <Form>
                    {
                            surveyQuestions.map((question) => (    
                                <QuestionComponent key={question.id.toString()} question={question}/>                                                                
                            ))}
                        <Link to="/surveys">
                            <Button variant="primary">Back</Button>
                        </Link>
                 </Form>
             </div>   
            )          
     }
}

