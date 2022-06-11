import Dropdown from 'react-bootstrap/Dropdown'
import { useState, useEffect, useRef } from 'react'
import { CustomMenu, CustomItem } from '../shared/CustomDropdown'

export default function SelectDay({ setSelectedDay, selectedDay, setSliderValues, selectedTime, days }) {
    const [show, setShow] = useState(false);


    const showDropdown = (e) => {
        setShow(!show);
    }
    const hideDropdown = e => {
        setShow(false);
    }



    var formatter = Intl.DateTimeFormat('sv-SE', {
        day: 'numeric',
        month: 'short'
    })
    return (
        <>
            <Dropdown show={show}
                onClick={showDropdown}
            >
                <Dropdown.Toggle variant='outline-success' title='Hello'>
                {selectedDay ? formatter.format(new Date(selectedDay.date)) : "Dag"} {selectedTime && selectedTime[0] + "-" + selectedTime[1]}
                </Dropdown.Toggle>
                <Dropdown.Menu as={CustomMenu}>
                    {days && days.map((day, index) => {
                        return <Dropdown.Item key={index} as={CustomItem} setSliderValues={setSliderValues} setSelectedDay={setSelectedDay} hideDropdown={hideDropdown} day={day} />
                    })}
                </Dropdown.Menu>
            </Dropdown>
        </>
    )
}