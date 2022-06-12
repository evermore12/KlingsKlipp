import { Button, Form, DropdownButton, Dropdown, Row, Col } from "react-bootstrap";
import Nouislider from 'nouislider-react'
import 'nouislider-react/node_modules/nouislider/distribute/nouislider.css'
import SelectDay from "./SelectDay";
import { useState, useEffect, useRef } from "react";
import { ScheduleSlider } from "./ScheduleSlider";
import ActionsMenu from "./ActionsMenu";
import styles from '../css/EditSchedule.module.css'
export default function EditSchedule() {
    const [selectedDay, setSelectedDay] = useState()
    const [updating, setUpdating] = useState(false)
    const [days, setDays] = useState()
    const scheduleSlider = useRef()


    function fetchSchedule(from, to) {
        fetch("/schedule/between?start=2022-06-06&end=2022-06-11")
            .then(res => res.json())
            .then(json => setDays(json))
    }

    useEffect(() => {
        fetchSchedule();
    }, [selectedDay])
    return (
        <>
            <Row className={`justify-content-center mt-3 ${styles.dropdown}`}>
                <Col xs='12'>
                    <SelectDay days={days} selectedDay={selectedDay} setSelectedDay={setSelectedDay} />
                </Col>
            </Row>
            
            {selectedDay &&
                <>
                    <Row className={`justify-content-center mt-5 mb-5 ${styles.slider}`} >
                        <Col xs='12'>
                            <ScheduleSlider slider={scheduleSlider} setUpdating={setUpdating} day={selectedDay}></ScheduleSlider>
                        </Col>
                    </Row>
                    <ActionsMenu scheduleSlider={scheduleSlider} updating={updating} selectedDay={selectedDay} setSelectedDay={setSelectedDay} />
                </>
            }
        </>
    )
}