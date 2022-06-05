import { useEffect, useState } from 'react'
import Dropdown from 'react-bootstrap/Dropdown'
import DropdownToggle from 'react-bootstrap/esm/DropdownToggle'
import '../css/Treatment.css'


export default function SelectTreatment({treatment, setTreatment}) {
    const [treatments, setTreatments] = useState()
    
    useEffect(() => {
        populateDropdown()
    }, [])
    function populateDropdown()
    {
        fetch('treatments')
            .then(res => res.json())
            .then(json => setTreatments(json))
    }
    return (
        <Dropdown onSelect={(key) => setTreatment(treatments[key])}>
                <DropdownToggle variant='outline-success'>
                {!treatment ? 'Behandling' : treatment.name}
                </DropdownToggle>
            <Dropdown.Menu >
            {treatments && treatments.map((treatment, index) => <Dropdown.Item key={index} eventKey={index}>{treatment.name}</Dropdown.Item>)}
            </Dropdown.Menu>
        </Dropdown>
    )
}