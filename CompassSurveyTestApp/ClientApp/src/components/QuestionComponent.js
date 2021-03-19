import React, { Component } from 'react';

export default class QuestionComponent extends Component {

    constructor(props) {
        super(props);
    }

    render() {
        const { question } = this.props;
        //input type can be anything and can be changed to support generic form with different inputs
        const inputType = "radio";
        return (
            <div className="form-group questionBox">
                <label htmlFor={question.id} > Question {question.id}</label>
                <p> {question.title} </p>
                {
                        question.options.map((option) => (                          
                        <div className="form-check" key={option.id.toString()}>
                            <input className="form-check-input radioStyle" type={inputType} name={"question" + question.id + option.id + "flexRadio"} id={"question" + question.id + option.id} />
                            <label className="form-check-label" htmlFor={"question" + question.id + option.id}>
                                        {option.optionText}
                                    </label>
                            </div>
                        ))
                }                   
            </div>
        )
    }

}
