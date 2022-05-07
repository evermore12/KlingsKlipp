import { useEffect, useState } from 'react'
import Dropdown from 'react-bootstrap/Dropdown'
import DropdownToggle from 'react-bootstrap/esm/DropdownToggle'
import '../css/Treatments.css'

export default function Treatments() {
    const [treatments, setTreatments] = useState()
    const [selectedTreatment, setSelectedTreatment] = useState()
    const [loading, isLoading] = useState(true)

    useEffect(() => {
        populateDropdown();
    }, [])

    async function populateDropdown() {
        let response = await fetch('weatherforecast');
        let data = await response.json();
        setTreatments(data);
        isLoading(false);
    }

    return (
        <Dropdown id='dropdown'>
                <DropdownToggle id='dropdown-toggle' variant='outline-success'>
                    {selectedTreatment ?
                    <>
                                       <p className='icon'>{selectedTreatment.icon}</p>
                                       <p className='name'>{selectedTreatment.name}</p>
                                       <p className='price'>{selectedTreatment.price} kr</p>
                                       </>
                :
                <p className='select-treatment'>
                    Välj behandling
                </p>
                }
 
                </DropdownToggle>
            <Dropdown.Menu id='dropdown-menu'>
                {!loading &&
                    treatments.map(treatment => {
                        return (
                            <>
                                <Dropdown.Item key={treatment.treatmentId} id='dropdown-item' href="#/action-1" onClick={() => setSelectedTreatment(treatment)}>
                                    <p className='icon'>{treatment.icon}</p>
                                    <p className='name'>{treatment.summary}</p>
                                    <p className='price'>{treatment.temperaturec}</p>
                                </Dropdown.Item>
                            </>
                        )
                    })}
            </Dropdown.Menu>
        </Dropdown>
    )
}