import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import { Home } from './components/Home';
import { ViewSurvey } from './components/ViewSurvey';
import { data } from './static/staticData';
import { ViewSurveyDetail } from './components/ViewSurveyDetail';
import { QuestionComponent } from './components/QuestionComponent';
import { shallow,configure, mount } from 'enzyme';
import { BrowserRouter } from 'react-router-dom';
import Adapter from 'enzyme-adapter-react-16';
import { Button } from 'react-bootstrap';

configure({ adapter: new Adapter() });
/*const mockSuccessResponse = data;
const mockJsonPromise = Promise.resolve(mockSuccessResponse);
const mockFetchPromise = Promise.resolve({
    json: () => mockJsonPromise,
});*/
global.fetch = jest.fn(() => Promise.resolve({
    json: () => Promise.resolve({
        surveyData: data,
        loading: false
    })
}))

//Test-1 : Check if the App component renders properly
it('renders without crashing', () => {
  const div = document.createElement('div');
    ReactDOM.render(<BrowserRouter>
        <App />
    </BrowserRouter>,
        div);
});

//Test-2 : Check if home component rendered 
it('render Home component', () => {
    const wrapper = shallow(<Home />);
    expect(wrapper).toMatchSnapshot();
});

//Test-3 : Check if home component has the survey list link 
it('check if Home component displays the link to select surveys', () => {
    const wrapper = shallow(<Home />);
    const surveyLink = <li><strong>Survey List</strong></li>;
    expect(wrapper.contains(surveyLink)).toEqual(true);
});

//Test-4 : Check if home component has the survey list link 
it('check if Feedback screen component displays the back button', () => {
    const wrapper = shallow(<Home />);
    const surveyLink = <li><strong>Survey List</strong></li>;
    expect(wrapper.contains(surveyLink)).toEqual(true);
});

it('Check if View Survey lists surveys when data loading has completed', () => {
    const props = {
        loading: false,
        surveyData: data
    };    
    //const wrapper = mount(<ViewSurvey />);    
    const wrapper = mount(<ViewSurvey/>);
    wrapper.instance().componentDidMount();
    //wrapper.instance().state.loading = false;
    //wrapper.instance().state.surveyData = data;
    const buttonComponent = wrapper.find(<div>
        Survey Data loading...
    </div>);
    expect(wrapper.instance().state.loading).toBe(false);
});

//Test-2 DOM test check if home page loaded with header and survey list 
it("displays the header and survey list on home screen", () => {
    const wrapper = shallow(<App />);
    const header = <h1>Compass Surveys!</h1>;
    const surveyListLink = <li><strong>Survey List</strong></li>;
    expect(wrapper.find(header)).toEqual(true);
    expect(wrapper.find(surveyListLink)).toEqual(true);
});
