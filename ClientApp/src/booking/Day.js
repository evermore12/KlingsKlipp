import '../css/Day.css'
import Dropdown from 'react-bootstrap/Dropdown'
import DropdownToggle from 'react-bootstrap/esm/DropdownToggle'
import TimeDropdown from './TimeDropdown'

export default function Day() {
    return (
        <Dropdown id='dropdown'>
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
        </Dropdown>)
}

