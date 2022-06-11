
import { useCallback, useEffect, useRef, useState } from 'react'
import { Container, Row, Col, Button } from 'react-bootstrap'
import EditSchedule from './EditSchedule'
import Book from './Book'
import '../css/App.css'
import Bookings from '../Bookings'

export default function App() {
    const [showingFront, setShowingFront] = useState(true)
    const inner = useRef()
    const front = useRef()
    const back = useRef()

    const eventListener = useCallback(() => {
        if (showingFront) {
            back.current.style.display = "none";
        }
        else {
            front.current.style.display = "none";
        }
    }, [showingFront])

    useEffect(() => {
        inner.current.addEventListener('transitionend', eventListener);
        return () => inner.current.removeEventListener('transitionend', eventListener)
    }, [eventListener])
    return (
        <>
            <Container className='flip-card app-container'>
                <div className="flip-card-inner" ref={inner}>
                    <div ref={front} className="flip-card-front">
                        <Book />
                    </div>
                    <div ref={back} className="flip-card-back">
                        <EditSchedule />
                    </div>
                </div>
            </Container>
            <Row className="justify-content-center pt-5 mt-5">
                <Col xs="auto">
                    <Button variant='outline-success' onClick={() => {
                        if (showingFront) {
                            back.current.style.display = "block";
                            inner.current.style.transform = "rotateY(540deg)"
                        }
                        else {
                            front.current.style.display = "block";
                            inner.current.style.transform = "rotateY(0deg)";

                        }
                        setShowingFront(!showingFront)
                    }}>{showingFront ? <i className="arrow right" /> : <i className="arrow left" />}</Button>
                </Col>
            </Row>

        </>
    )
}

