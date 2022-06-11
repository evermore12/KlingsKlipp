import { useState, useEffect } from 'react'
import { Container, Row, Col, Button, Dropdown, ButtonGroup, DropdownButton } from 'react-bootstrap'
import { Box, selectClasses } from '@mui/material'
import { CustomToggle, CustomMenu } from '../shared/CustomDropdown'
import SelectDay from '../shared/SelectDay'
// import Time_Not_React from './booking/Time-non-react'
import SelectTreatment from '../Book/SelectTreatment'
import SelectTimeblock from '../Book/SelectTimeblock'
import DropdownItem from 'react-bootstrap/esm/DropdownItem'
import { BookTime } from '../Book/BookTime'
import { ContactInformation } from '../Book/ContactInformation'
import { message } from 'antd';
import '../css/Book.css'

const Book = () => {
    const [selectedTreatment, setSelectedTreatment] = useState()
    const [selectedDay, setSelectedDay] = useState()
    const [selectedTimeblock, setSelectedTimeblock] = useState()
    const [schedule, setSchedule] = useState()
    const [selectedTime, setSelectedTime] = useState()
    const [contactInformation, setContactInformation] = useState({name: "", phone: ""});
    const [loading, setLoading] = useState(false)

    function fetchSchedule(from, to) {
        fetch("/schedule/between?start=2022-06-06&end=2022-06-11&onlyAvailable=true")
            .then(res => res.json())
            .then(json => setSchedule(json))
    }
    const success = () => {
        message.success('Added booking for ' + contactInformation.name);
    };
    const error = () => {
        message.error('Something went wrong');
      };
    function Book()
    {
        setLoading(true)
        fetch("/booking", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                treatment: selectedTreatment,
                customer: {name: "Jonathan", Phone: "07127341"},
                timeblockId: selectedTimeblock.id,
                timeBlock: selectedTimeblock

            })
        }).then(res => {
            if(!res.ok){
                throw new Error()
            }
            return res.json()})
            .then(json => console.log(json)).then(() => {success(); } )
            .catch(err => {console.log(err); error() }).finally(() => setLoading(false))
    }

    useEffect(() => {
        fetchSchedule();
    }, [selectedDay])
    return (
        <div>
            <Row className="justify-content-center mt-3">
                <Col xs="12">
                    <SelectTreatment selectedTreatment={selectedTreatment} setSelectedTreatment={setSelectedTreatment} />
                </Col>
            </Row>
            <Row className="justify-content-center mt-3">
                <Col xs="12">
                    <SelectDay selectedTime={selectedTime} days={schedule} setSelectedDay={setSelectedDay} selectedDay={selectedDay} selectedTreatment={selectedTreatment} />
                </Col>
            </Row>
            {selectedDay &&
                <Row className="justify-content-center mt-3 book-time">
                    <Col xs='12'>
                        {!selectedTimeblock ?
                            <SelectTimeblock setSelectedTimeblock={setSelectedTimeblock} selectedTreatment={selectedTreatment} day={selectedDay} />
                            : <BookTime setSelectedTime={setSelectedTime} selectedTreatment={selectedTreatment} selectedTimeblock={selectedTimeblock} />
                        }
                    </Col>
                </Row>
            }
            {selectedTimeblock &&
                <>
                    <Row className="justify-content-center contact-information">
                        <Col xs='12'>
                            <ContactInformation contactInformation={contactInformation} setContactInformation={setContactInformation}/>
                        </Col>
                    </Row>
                    <Row className="justify-content-center mt-3">
                        <Col xs='auto'>
                            <Button onClick={Book}>
                                Boka
                            </Button>
                        </Col>
                    </Row>
                </>
            }


        </div>
    )

}


export default Book