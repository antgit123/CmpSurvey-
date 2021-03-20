import React, { Component } from 'react';
import { Col, Grid, Row } from 'react-bootstrap';
import { NavMenu } from './NavMenu';

export class SurveyLayout extends Component {
    displayName = SurveyLayout.name

    render() {
        return (
            <Grid fluid>
                <Row>
                    <Col sm={2}>
                        
                    </Col>                    
                    <Col sm={8}>
                        <div className="appContainer"> 
                            {this.props.children}
                        </div>
                    </Col>
                    <Col sm={2}/>
                </Row>
            </Grid>
        );
    }
}
