import './App.css'
import Summary from './components/Summary'
import Treatments from './components/Treatments'
import Day from './components/Day'
import Time from './components/Time'
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
