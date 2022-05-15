import './App.css'
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
            <div className='Summary'>
                <Summary treatment={treatment} day={day} time={time} />
            </div>
            <div className='Treatments'>
                <Treatments setTreatment={setTreatment} />
            </div>
            <div className='Day'>
                <Day setDay={setDay} />
            </div>
            <div className='Time'>
                <Time setTime={setTime} />
            </div>
        </div>
    )
}
