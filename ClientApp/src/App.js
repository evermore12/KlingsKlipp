import './App.css'
import Summary from './components/booking/Summary'
import Treatments from './components/booking/Treatments'
import Day from './components/booking/Day'
import Time from './components/booking/Time'
import { useState } from 'react'
export default function App() {

    const [treatment, setTreatment] = useState()
    return (
        <div className="App">
            <div className='Summary'>
                <Summary />
            </div>
            <div className='Treatments'>
                <Treatments />
            </div>
            <div className='Day'>
                <Day />
            </div>
            <div className='Time'>
                <Time />
            </div>
        </div>
    )
}
