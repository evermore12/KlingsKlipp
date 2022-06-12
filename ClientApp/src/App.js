
import { useCallback, useEffect, useRef, useState } from 'react'
import { Container, Row, Col, Button } from 'react-bootstrap'
import EditSchedule from './components/EditSchedule'
import Book from './components/Book'
import { Flipcard, Back, Front } from './components/Flipcard'
import FlipButton from './components/Flipcard'
import './App.css'
import Bookings from './components/Bookings'

export default function App() {
    return (
        <>
            <Container>
                <Flipcard front={<Book />} back={<EditSchedule />}>
                    <Front>
                        <Book />
                    </Front>
                    <Back>
                        <EditSchedule/>
                    </Back>
                </Flipcard>
            </Container>
        </>
    )
}

