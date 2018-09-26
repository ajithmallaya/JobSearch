import { shallow } from 'enzyme';

import * as React from 'react';

import App from './App';
import { configure } from 'enzyme';
import Adapter from 'enzyme-adapter-react-16';

configure({ adapter: new Adapter() });
describe('App SnapShot', () => {

  it('should match snapshot', () => {
      const wrapper = shallow(<App />);
      expect(wrapper.find('div')).toMatchSnapshot();
  });

});
