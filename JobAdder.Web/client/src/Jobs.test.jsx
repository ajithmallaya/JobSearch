import { shallow } from 'enzyme';
import * as React from 'react';
import Jobs from './Jobs';
import { configure } from 'enzyme';
import Adapter from 'enzyme-adapter-react-16';

configure({ adapter: new Adapter() });
describe('Jobs SnapShot', () => {

  it('should match snapshot', () => {
      const wrapper = shallow(<Jobs />);
      expect(wrapper.find('div')).toMatchSnapshot();
  });

});
