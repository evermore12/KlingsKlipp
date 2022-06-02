import '../css/Day.css'
import Dropdown from 'react-bootstrap/Dropdown'
import DropdownButton from 'react-bootstrap/DropdownButton'
import { useState, useEffect} from 'react'

import Nouislider from 'nouislider-react'
import 'nouislider-react/node_modules/nouislider/distribute/nouislider.css'

export default function Day({ day, setDay }) {
    const [availableDays, setAvailableDays] = useState()
    useEffect(() => {
        populateDropdown();
    }, [])

    function getBookings(index){
        return [availableDays[index].start, new Date(availableDays[index].start).setHours(new Date(availableDays[index].start).getHours() + 1)]
    }
    function populateDropdown() {
        console.log("hi")
        fetch('schedule/from' + '?' + new Date())
            .then(res => res.json())
            .then(json => {console.log(json); setAvailableDays(json)})
    }
    var formatter = Intl.DateTimeFormat('sv-SE', {
        day: 'numeric',
        month: 'short'
    })
    return (
        <>
            <DropdownButton variant='outline-success' onSelect={(key) => setDay(availableDays[key])} title={!day ? 'Dag' : formatter.format(day.start)}>
                {availableDays && availableDays.map((day, index) =>
                    <Dropdown.Item key={index} eventKey={index} className='day-dropdown-item'>
                        <div className='dropdown-item-container'>
                            <span style={{ whiteSpace: 'pre-line' }}>
                            <p className='date'>{formatter.formatToParts(day.start)[0].value}</p>
                                    <p className='date'>{formatter.formatToParts(day.start)[2].value}</p>
                            </span>
                            <div className='date'>

                            </div>
                            <div className='slider'>
                                <Nouislider
                                    range=
                                    {
                                        {
                                            min: day.start,
                                            max: day.end
                                        }
                                    }
                                    start = {getBookings(index)}
                                    behaviour ='drag-all'
                                    connect =
                                    {
                                        [false, true, false]
                                    }
                                />
                            </div>
                        </div>
                    </Dropdown.Item>)}
            </DropdownButton>
        </>
    )
}