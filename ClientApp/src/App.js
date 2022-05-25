import './App.css'
import { useState } from 'react'
import { Container, Row, Col } from 'react-bootstrap'
import { Box } from '@mui/material'
import Treatment from './booking/Treatment'
import Day from './booking/Day'
// import Time_Not_React from './booking/Time-non-react'
import Time from './booking/Time'

export default function App() {
    const [day, setDay] = useState()
    const [treatment, setTreatment] = useState()
    // const [time, setTime] = useState()
    
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
                        <Treatment treatment={treatment} setTreatment={setTreatment} />
                    </Col>
                </Row>
                <Row className="justify-content-center mt-3">
                    <Col xs='12'>
                        <Day day={day} setDay={setDay} />
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
                        {day &&
                            <Time treatment={treatment} day={day} />
                        }
                    </Col>
                </Row>
            </Container>
        </>
    )
}
