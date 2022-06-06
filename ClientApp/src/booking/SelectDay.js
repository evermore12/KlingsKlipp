import '../css/Day.module.css'
import Dropdown from 'react-bootstrap/Dropdown'
import DropdownButton from 'react-bootstrap/DropdownButton'
import { useState, useEffect} from 'react'




import Nouislider from 'nouislider-react'
import 'nouislider-react/node_modules/nouislider/distribute/nouislider.css'

export default function SelectDay({ day, setDay }) {
    const [schedule, setSchedule] = useState()

    async function fetchSchedule(from, to) {
        fetch("schedule/between?start=" + from + "&" + "end=" + to)
            .then(res => res.json())
    }

    useEffect(() => {
        fetchSchedule().then(json => setSchedule(json));
    }, [])

    var formatter = Intl.DateTimeFormat('sv-SE', {
        day: 'numeric',
        month: 'short'
    })
    return (
        <>
            <DropdownButton variant="outline-success" onSelect={(key) => setDay(schedule[key])} title={!day ? 'Dag' : formatter.format(day.start)}>
                {schedule && schedule.map((day, index) =>
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
                                    start = {[10]}
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