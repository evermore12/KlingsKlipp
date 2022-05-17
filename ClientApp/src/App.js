import './App.css'
import { useEffect, useState } from 'react'
import { Dropdown, DropdownButton, Container, Row, Col } from 'react-bootstrap'
import { Box } from '@mui/material'
import Treatment from './booking/Treatment'
import Day from './booking/Day'
import Time from './booking/Time'

export default function App() {
    const [selectedDay, setSelectedDay] = useState()
    const [selectedTreatment, setSelectedTreatment] = useState()
    const [selectedTime, setSelectedTime] = useState()

    return (
        <>
            <Container>
                <Row className="justify-content-center mt-5 mb-1">
                    <Col xs='12'>
                        <Box sx={{
                            height: 100,
                            outline: '1px green solid'
                        }} />
                    </Col>
                </Row>
                <Row className="justify-content-center mt-3">
                    <Col xs='12'>
                        <Treatment selectedTreatment={selectedTreatment} setSelectedTreatment={setSelectedTreatment} />
                    </Col>
                </Row>
                <Row className="justify-content-center mt-3">
                    <Col xs='12'>
                        <Day selectedDay={selectedDay} setSelectedDay={setSelectedDay} />
                    </Col>
                </Row>
                <Row className="justify-content-center mt-3">
                    <Col xs='12'>
                        {!selectedDay &&
                            <Time selectedDay={selectedDay} setSelectedTime={setSelectedTime} />
                        }
                    </Col>
                </Row>
            </Container>
        </>
    )
}
