import React, { Component } from 'react';
import { Button,Row } from 'react-bootstrap';
import { Link } from 'react-router-dom';

export class FeedbackScreenComponent extends Component {

    constructor(props) {
        super(props);
    }

    render() {
        const { loading, message, backButtonUrl } = this.props;
        if (loading) {
            return (
                <div>
                    {message}
                </div>
            )                           
        }
        return (
            <div className="feedbackDiv">
                <Row>
                    <p>{message}</p>
                </Row>
                <Row>
                    <Link to={backButtonUrl} >
                        <Button variant="primary">Back</Button>
                    </Link>
                </Row>                
             </div>
        )        
    }
}