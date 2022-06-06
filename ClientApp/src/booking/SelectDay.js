import styles from '../css/Day.module.css'
import Dropdown from 'react-bootstrap/Dropdown'
import DropdownButton from 'react-bootstrap/DropdownButton'
import { useState, useEffect } from 'react'




import Nouislider from 'nouislider-react'
import 'nouislider-react/node_modules/nouislider/distribute/nouislider.css'
import { Col, Container, Row } from 'react-bootstrap'

export default function SelectDay({ day, setDay }) {
    const [schedule, setSchedule] = useState()

    function fetchSchedule(from, to) {
        fetch("/schedule/between?start=2022-06-06&end=2022-06-10")
            .then(res => { return res.json() })
            .then(json => { setSchedule(json); console.log(json) })
    }

    useEffect(() => {
        fetchSchedule();
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
                        <Container className={styles.container}>
                            <Row xs="auto">
                                <Col xs="2">
                                    <p className='date'>{formatter.formatToParts(new Date(day.date))[0].value}</p>
                                    <p className='date'>{formatter.formatToParts(new Date(day.date))[2].value}</p>
                                </Col>
                                <Col xs="10">
                                    <Nouislider
                                        range=
                                        {
                                            {
                                                min: 0,
                                                max: 1000 * 60 * 60 * 24
                                            }
                                        }
                                        start={10}
                                        behaviour='drag-all'
                                        connect=
                                        {
                                            [true, false]
                                        }
                                    />
                                </Col>
                            </Row>
                        </Container>
                        {/* <div className='dropdown-item-container'>
                            <span style={{ whiteSpace: 'pre-line' }}>
                            <p className='date'>{formatter.formatToParts(new Date(day.date))[0].value}</p>  
                            <p className='date'>{formatter.formatToParts(new Date(day.date))[2].value}</p>                                  
                            </span>
                            <div className='date'>
                            </div>
                            <div className='slider'>
                                <Nouislider
                                    range=
                                    {
                                        {
                                            min: 0,
                                            max: 1000 * 60 * 60 * 24
                                        }
                                    }
                                    start = {10}
                                    behaviour ='drag-all'
                                    connect =
                                    {
                                        [true, false]
                                    }
                                />
                            </div>
                        </div> */}
                    </Dropdown.Item>)}
            </DropdownButton>
        </>
    )
}