import { Row, Col, Button, Spinner } from "react-bootstrap";
import { useEffect, useState } from "react";
import { TimePicker } from 'antd';
import { message } from 'antd';
import 'antd/dist/antd.css';
const ActionsMenu = ({ updating, selectedDay, setSelectedDay, scheduleSlider }) => {
    const defaultTime = ["08:00", "12:00"]
    const [selectedTime, setSelectedTime] = useState(defaultTime);
    const [loading, setLoading] = useState(false)
    const [lastMoved, setLastMoved] = useState()

    function setAvailableTime(time, timeString) {
        fetch("/schedule", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(
                {
                    start: selectedTime[0],
                    end: selectedTime[1],
                    dayId: selectedDay.date
                })
        }).then(res => res.json()).then(json => setSelectedDay(json))
    }


    const success = () => {
        message.success('Updated schedule for ' + selectedDay.date);
    };
    const error = () => {
        message.error('Something went wrong');
      };

    function resetSlider() {
        let array = new Array();
        if (selectedDay.timeblocks) {
            array = selectedDay.timeblocks.flatMap((timeblock) => {
                return [timeblock.startUnix, timeblock.endUnix]
            })
        }
        else {
            array = [1]
        }
        scheduleSlider.current.noUiSlider.set(array, true);
    }
    function updateAvailableTimes() {
        setLoading(true)
        let updatedDay = selectedDay;
        let sliderValues = scheduleSlider.current.noUiSlider.get();
        let sliderValuesRaw = scheduleSlider.current.noUiSlider.get(true);
        let count = 0;
        for (let index = 0; index < updatedDay.timeblocks.length; index++) {
            const timeblock = selectedDay.timeblocks[index];
            timeblock.start = sliderValues[count]
            timeblock.startUnix = sliderValuesRaw[count]
            count++
            timeblock.end = sliderValues[count]
            timeblock.endUnix = sliderValuesRaw[count]
            count++
        }
        setSelectedDay(selectedDay)
        fetch("/schedule", {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(updatedDay)
        }).then(res => {
            if(!res.ok){
                throw new Error()
            }
            return res.json()})
            .then(json => setSelectedDay(json)).then(() => {success(); resetSlider() } )
            .catch(err => {console.log(err); error() }).finally(() => setLoading(false))

        console.log(updatedDay);
    }
    function clearSchedule()
    {
        fetch(`/schedule/day?date=${selectedDay.date}`, {
            method: 'DELETE'
        }).then(res => res.json()).then(setSelectedDay(null))
    }

    return (
        <>
            {updating ?
                <>
                    <Row className={`justify-content-center mb-1`} >
                        <Col xs="auto">
                            <Button variant="outline-primary" onClick={updateAvailableTimes}>

                                {loading
                                    ?
                                    <Spinner
                                        as="span"
                                        animation="border"
                                        size="sm"
                                        role="status"
                                        aria-hidden="true"
                                    />

                                    : "Update"
                                }

                            </Button>
                        </Col>
                        <Col xs='auto'>
                        <Button onClick={resetSlider} variant="outline-warning">Reset</Button>
                        </Col>
                        <Col xs='auto'>
                        <Button onClick={clearSchedule} variant="outline-danger">Clear</Button>                        </Col>
                    </Row>
                </>
                :
                <>
                    <Row className={`justify-content-center mt-5`} >
                        <Col xs='auto'>
                            <TimePicker.RangePicker onChange={(time, timeString) => setSelectedTime(timeString)} minuteStep={10} format={"HH:mm"} placeholder={defaultTime} />
                        </Col>
                    </Row>
                    <Row className={`justify-content-center mt-3 mb-2`} >
                        <Col xs='auto'>
                            <Button onClick={setAvailableTime} variant="outline-success">Add Time</Button>
                        </Col>
                        <Col xs='auto'>
                            <Button onClick={clearSchedule} variant="outline-danger">Clear</Button>
                        </Col>
                    </Row>
                </>
            }
        </>

    )
}
export default ActionsMenu;