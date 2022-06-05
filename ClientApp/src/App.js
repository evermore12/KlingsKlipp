import './App.css'
import { useState } from 'react'
import { Container, Row, Col } from 'react-bootstrap'
import { Box, selectClasses } from '@mui/material'
import Summary from '.booking/Summary'
import SelectDay from './booking/SelectDay'
// import Time_Not_React from './booking/Time-non-react'
import SelectTreatment from './booking/SelectTreatment'
import SelectTime from './booking/SelectTime'

export default function App() {
    const [selectedTreatment, setSelectedTreatment] = useState()
    const [selectedDay, setSelectedDay] = useState()
    const [selectedTime, setSelectedTime] = useState()
    
    return (
        <>
            <Container>
                <Row className="justify-content-center mt-5 mb-1">
                    <Col xs='12'>
                        <Summary selectedTreatment={selectedTreatment} selectedDay={selectedDay} selectedTime={selectedTime} />
                    </Col>
                </Row>
                <Row className="justify-content-center mt-3">
                    <Col xs='12'>
                        <SelectTreatment selectedTreatment={selectedTreatment} setSelectedTreatment={setSelectedTreatment} />
                    </Col>
                </Row>
                <Row className="justify-content-center mt-3">
                    <Col xs='12'>
                        <SelectDay selectedTreatment={selectedTreatment} selectedDay={selectedDay} setSelectedDay={setSelectedDay} />
                    </Col>
                </Row>
                {/* <Row className="justify-content-center mt-3">
                    <Col xs='12'>
                        {selectedDay &&
                            <Time_Not_React treatment={selectedTreatment} selectedDay={selectedDay} setSelectedTime={setSelectedTime} />
                        }
                    </Col>
                </Row> */}
                <Row className="justify-content-center mt-4">
                    <Col xs='12'>
                        {selectedDay &&
                            <SelectTime selectedTreatment={selectedTreatment} selectedDay={selectedDay} setSelectedTime={setSelectedTime} />
                        }
                    </Col>
                </Row>
            </Container>
        </>
    )
}
