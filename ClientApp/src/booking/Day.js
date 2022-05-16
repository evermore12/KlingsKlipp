import '../css/Day.css'
import Dropdown from 'react-bootstrap/Dropdown'
import DropdownToggle from 'react-bootstrap/esm/DropdownToggle'
import TimeDropdown from './TimeDropdown'
import Select from '@mui/material/Select'
import Nouislider from 'nouislider-react'
import { MenuItem, InputLabel, Box, FormControl } from '@mui/material'
import { useState, useEffect, useRef } from 'react'

var startTime = new Date(2022, 4, 12, 8).getTime()
var endTime = new Date(2022, 4, 12, 17).getTime()
export default function Day() {
    const [age, setAge] = useState('')
    const [kek, setKek] = useState()
    const slider = useRef();

    const handleChange = (event) => {
        setKek(2)
    };
    return (
        <>
   <Box sx={{ minWidth: 120 }}>
      <FormControl fullWidth>
        <InputLabel id="demo-simple-select-label">Age</InputLabel>
        <Select
          labelId="demo-simple-select-label"
          id="demo-simple-select"
          value={age}
          label="Age"
          onChange={handleChange}
        >
          <MenuItem value={10}>
          <Nouislider/>
              </MenuItem>
          <MenuItem value={20}>
              <Nouislider/>
              </MenuItem>
          <MenuItem value={30}>
          <Nouislider/>
              </MenuItem>
        </Select>
      </FormControl>
    </Box>
      </>

)
}

{/* <Dropdown id='dropdown'>
<DropdownToggle id='dropdown-toggle' variant='outline-success'>
    <p className='select-treatment'>
        Välj dag
    </p>
</DropdownToggle>
<Dropdown.Menu id='dropdown-menu'>
    <Dropdown.Item id='dropdown-item' key='ello' href="#/action-1" >
        <TimeDropdown startTime={new Date(2022, 4, 12, 8).getTime()} endTime={new Date(2022, 4, 12, 17).getTime()}/>
    </Dropdown.Item>
    <Dropdown.Item id='dropdown-item' key='ello1' href="#/action-1" >
        <TimeDropdown startTime={new Date(2022, 4, 12, 8).getTime()} endTime={new Date(2022, 4, 12, 17).getTime()}/>
    </Dropdown.Item>
</Dropdown.Menu>
</Dropdown> */}