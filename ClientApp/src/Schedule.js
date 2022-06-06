import { Button, Form, DropdownButton, Dropdown, Row, Col } from "react-bootstrap";
import './css/api/add.module.css'
import Nouislider from 'nouislider-react'
import 'nouislider-react/node_modules/nouislider/distribute/nouislider.css'
import SelectDay from "./booking/SelectDay";
import { useState, useEffect } from "react";
export default function Schedule() {
    const [selectedDay, setSelectedDay] = useState()

    var formatterSlider = Intl.DateTimeFormat('sv-SE', {
        timeStyle: 'short'
    })

    const [schedule, setSchedule] = useState()


    function getBookings(index) {
        return [schedule[index].start, new Date(schedule[index].start).setHours(new Date(schedule[index].start).getHours() + 1)]
    }

    var formatter = Intl.DateTimeFormat('sv-SE', {
        day: 'numeric',
        month: 'short'
    })
    return (
        <>
            <Row className="justify-content-center mt-3">
                <Col xs='12'>
                    <SelectDay />
                </Col>
            </Row>
            <Row className="justify-content-center mt-3">
                <Col xs='12'>
                    <Nouislider
                        range=
                        {
                            {
                                min: 0,
                                max: 1000 * 60 * 60 * 23
                            }
                        }
                        start=
                        {
                            [
                                1000 * 60 * 60 * 8,
                                1000 * 60 * 60 * 17
                            ]
                        }
                        behaviour='drag'
                        connect=
                        {
                            [false, true, false]
                        }
                        step=
                        {
                            1000 * 60 * 10
                        }
                        tooltips
                        format={
                            {
                                to: function (value) {
                                    return formatterSlider.format(new Date(value));
                                },
                                from: function (value) {
                                    return value
                                }
                            }

                        }
                    />
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