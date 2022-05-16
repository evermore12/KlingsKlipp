import '../css/Day.css'
import Dropdown from 'react-bootstrap/Dropdown'
import DropdownToggle from 'react-bootstrap/esm/DropdownToggle'
import TimeDropdown from './TimeDropdown'
import Select from '@mui/material/Select'
import { MenuItem, InputLabel, Box, FormControl } from '@mui/material'
import { useState } from 'react'

export default function Day() {
    const [age, setAge] = useState('')

    const handleChange = (event) => {
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
          <TimeDropdown startTime={new Date(2022, 4, 12, 8).getTime()} endTime={new Date(2022, 4, 12, 17).getTime()}/>
              </MenuItem>
          <MenuItem value={20}>
          <TimeDropdown startTime={new Date(2022, 4, 12, 8).getTime()} endTime={new Date(2022, 4, 12, 17).getTime()}/>
              </MenuItem>
          <MenuItem value={30}>
          <TimeDropdown startTime={new Date(2022, 4, 12, 8).getTime()} endTime={new Date(2022, 4, 12, 17).getTime()}/>
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