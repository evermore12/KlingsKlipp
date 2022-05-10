import './App.css'
import Summary from './components/Summary'
import Treatments from './components/Treatments'
import Day from './components/Day'
import Time from './components/Time'
import CustomizedSlider from './components/CustomizedSlider'
export default function App() {
    return (
        <div className="App">
            <Summary />
            <Treatments />
            <Day />
            <Time />
        </div>

    )
}
