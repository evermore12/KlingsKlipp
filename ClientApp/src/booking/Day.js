import '../css/Day.css'
import Dropdown from 'react-bootstrap/Dropdown'
import DropdownToggle from 'react-bootstrap/esm/DropdownToggle'
import { useState, useEffect, useRef } from 'react'

export default function Day({selectedDay, setSelectedDay}) {
    const [days, setDays] = useState()
    useEffect(() => {
        populateDropdown();
    }, [])

    function populateDropdown()
    {
        fetch('days')
        .then(res => res.json())
        .then(json => setDays(json.map(treatment => <Dropdown.Item value={treatment.name}></Dropdown.Item>)))
    }
    return (
        <Dropdown onSelect={(key, event) => setSelectedDay(event.currentTarget.innerHTML)}>
                <DropdownToggle variant='outline-success'>
                {!selectedDay ? 'Dag' : selectedDay}
                </DropdownToggle>
            <Dropdown.Menu>
                {days}
            </Dropdown.Menu>
        </Dropdown>

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