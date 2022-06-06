
import { useRef, useState } from 'react'
import { Container, Row, Col, Button } from 'react-bootstrap'
import Schedule from './Schedule'
import Booking from './Booking'

export default function App() {
    const [showingApi, showApi] = useState(false)
    const card = useRef()
    const inner = useRef()

    return (
        <>
            <Container className='flip-card mt-5' ref={card}>
                        <div className="flip-card-inner" ref={inner}>
                            <div className="flip-card-front">
                            <Booking />

                            </div>
                            <div className="flip-card-back">
                                                                <Schedule />
                            </div>
                        </div>
            </Container>

            <Row className="justify-content-center mt-3">
                    <Col xs="auto">
                        <Button variant='outline-success' onClick={() => {showingApi ? inner.current.style.transform = "rotateY(0deg)" : inner.current.style.transform = "rotateY(540deg)"; showApi(!showingApi)} }><i className="arrow left"/><i className="arrow right"/></Button>
                    </Col>
                </Row>

        </>
    )
}

