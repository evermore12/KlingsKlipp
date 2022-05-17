import { useEffect, useState } from 'react'
import Dropdown from 'react-bootstrap/Dropdown'
import DropdownToggle from 'react-bootstrap/esm/DropdownToggle'
import '../css/Treatment.css'


export default function Treatment({selectedTreatment, setSelectedTreatment}) {
    const [treatments, setTreatments] = useState()
    useEffect(() => {
        populateTreatmentData()
    }, [])

    function populateTreatmentData()
    {
        fetch('treatments')
            .then(res => res.json())
            .then(json => setTreatments(json))
    }
    return (
        <Dropdown onSelect={(key) => console.log(treatments[key])}>
                <DropdownToggle variant='outline-success'>
                {!selectedTreatment ? 'Behandling' : selectedTreatment}
                </DropdownToggle>
            <Dropdown.Menu >
            {treatments && treatments.map((treatment, index) => <Dropdown.Item key={index} eventKey={index}>{treatment.name}</Dropdown.Item>)}
            </Dropdown.Menu>
        </Dropdown>
    )
}