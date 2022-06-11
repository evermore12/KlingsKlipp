import { Button, Form, DropdownButton, Dropdown, Row, Col } from "react-bootstrap";
import Nouislider from 'nouislider-react'
import 'nouislider-react/node_modules/nouislider/distribute/nouislider.css'
import SelectDay from "../Book/SelectDay";
import { useState, useEffect } from "react";
import { UpdateTimeblocks } from "../EditSchedule/ScheduleSlider";
export default function EditSchedule() {
    const [selectedDay, setSelectedDay] = useState()

    return (
        <>
            <Row className="justify-content-center mt-3">
                <Col xs='12'>
                    <SelectDay setSelectedDay={setSelectedDay}/>
                </Col>
            </Row>
            <Row className="justify-content-center mt-3">
                <Col xs='12'>
                    <UpdateTimeblocks day={selectedDay}></UpdateTimeblocks>
                </Col>
            </Row>
            <Row className="justify-content-center mt-3">
                <Col xs='auto'>
                    <Button variant="outline-success">Add block</Button>
                </Col>
            </Row>


        </>
    )
}