import React from 'react';
import { withStyles } from '@material-ui/core/styles';
import Tabs from '@material-ui/core/Tabs';
import { TabsContext } from './TabsContainer';

const StyledTabs = withStyles({
  root: {
    borderBottom: '100px solid #e8e8e8',
  },
  indicator: {
    backgroundColor: '#1890ff',
  },
})((props) => {
  const {value, setValue} = React.useContext(TabsContext);
  // console.log(x);
  // const {value, setValue} = x;
  const handleChange = (event, newValue) => {
    setValue(newValue);
  };

  return(
    <Tabs value={value} variant="fullWidth" onChange={handleChange} aria-label="tab-container">
      {props.children}
    </Tabs>
  );
});

export default StyledTabs;