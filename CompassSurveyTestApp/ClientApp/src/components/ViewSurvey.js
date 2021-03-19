import React, { Component } from 'react';
import { Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';

export class ViewSurvey extends Component {
    //state = { surveys: [], selectedSurvey: null };
    loadSurveyData = () => {
      /*  const data = {
            "surveys": [
                {
                    "id": "1",
                    "name": "Survey 1",
                    "questions": [
                        {
                            "id": "53",
                            "createdBy": "Elisabeth Winters",
                            "createdDateTime": "Fri, 22 May 2020 01:11:00 GMT",
                            "title": "How many astronauts landed on the moon?",
                            "subTitle": "",
                            "questionType": 3,
                            "options": [
                                {
                                    "id": "1",
                                    "text": "1"
                                },
                                {
                                    "id": "2",
                                    "text": "3"
                                },
                                {
                                    "id": "3",
                                    "text": "18"
                                }
                            ]
                        },
                        {
                            "id": "72",
                            "createdBy": "Maryam O'Ryan",
                            "createdDateTime": "Tue, 26 May 2020 05:57:52 GMT",
                            "title": "How many devs does it take to change a lightbulb?",
                            "subTitle": "This is not a trick question.",
                            "questionType": 3,
                            "options": [
                                {
                                    "id": "1",
                                    "text": "One"
                                },
                                {
                                    "id": "2",
                                    "text": "Two"
                                },
                                {
                                    "id": "3",
                                    "text": "Three thousand three hundred eighty-seven"
                                }
                            ]
                        }
                    ]
                },
                {
                    "id": "2",
                    "name": "Survey 2",
                    "questions": [
                        {
                            "id": "34",
                            "createdBy": "Andre Grid",
                            "createdDateTime": "Thur, 28 May 2020 09:30:00 GMT",
                            "title": "What is the temp today?",
                            "subTitle": "We need to send this to the Bureau of Meteorology.",
                            "questionType": 3,
                            "options": [
                                {
                                    "id": "1",
                                    "text": "10°"
                                },
                                {
                                    "id": "2",
                                    "text": "20°"
                                },
                                {
                                    "id": "3",
                                    "text": "30°"
                                }
                            ]
                        }
                    ]
                }
            ]
        }; 
        this.setState({ surveyData: data, loading: false}); */
    }

    onSelectSurvey = (survey) => {
        this.setState({ selectedSurvey: survey });
    }
    constructor(props) {
        super(props);
        this.state = { surveyData: [], selectedSurvey: null, loading: true };

       fetch('api/Surveys')
             .then(response => response.json())
             .then(data => {
                 this.setState({ surveyData: data, loading: false });
             });      
    }

    componentDidMount() {
        this.loadSurveyData();
    }
    render() {        
        if (this.state.loading) {
            return (
                <div> Data loading...</div>
            )
        }
        return (
            <div>
                <h3 className="appHeader"> Compass Surveys </h3>
                {this.state.surveyData.surveys.map((survey) => (
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