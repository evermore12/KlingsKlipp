import { useState } from 'react'
import { Container, Row, Col, Button } from 'react-bootstrap'
import { Box, selectClasses } from '@mui/material'
import Summary from './booking/Summary'
import './App.css'
import SelectDay from './booking/SelectDay'
// import Time_Not_React from './booking/Time-non-react'
import SelectTreatment from './booking/treatment'
import SelectTime from './booking/SelectTime'

const Booking = () => {
    const [selectedTreatment, setSelectedTreatment] = useState()
    const [selectedDay, setSelectedDay] = useState()
    const [selectedTime, setSelectedTime] = useState()
    return(
        <div>
        <Row className="justify-content-center mt-3">
            <Col xs="12">
                <SelectTreatment selectedTreatment={selectedTreatment} setSelectedTreatment={setSelectedTreatment} />
            </Col>
        </Row>
        <Row className="justify-content-center mt-3">
            <Col xs="12">
                <SelectDay selectedTreatment={selectedTreatment} selectedDay={selectedDay} setSelectedTime={setSelectedTime} />
            </Col>
        </Row>
        <Row className="justify-content-center mt-3">
            <Col xs='12'>
                {selectedDay &&
                    <SelectTime selectedTreatment={selectedTreatment} selectedDay={selectedDay} setSelectedTime={setSelectedTime} />
                }
            </Col>
        </Row>
    </div>
    )

}


export default Booking