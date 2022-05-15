import './css/App.css'
import Summary from './booking/Summary'
import Treatments from './booking/Treatments'
import Day from './booking/Day'
import Time from './booking/Time'
import { useState } from 'react'
export default function App() {
    const [treatment, setTreatment] = useState()
    const [day, setDay] = useState()
    const [time, setTime] = useState()

    return (
        <div className="App">
            <div treatment={treatment} day={day} time={time} className='Summary'>
                <Summary />
            </div>
            <div setTreatment={setTreatment} className='Treatments'>
                <Treatments />
            </div>
            <div setDay={setDay} className='Day'>
                <Day />
            </div>
            <div setTime={setTime} className='Time'>
                <Time />
            </div>
        </div>
    )
}
