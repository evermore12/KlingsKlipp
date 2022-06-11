import { useEffect, useState } from 'react'
import Dropdown from 'react-bootstrap/Dropdown'
import DropdownToggle from 'react-bootstrap/esm/DropdownToggle'
import styles from '../css/Treatment.module.css'

export default function Treatment({ selectedTreatment, setSelectedTreatment }) {
    const [treatments, setTreatments] = useState()

    useEffect(() => {
        populateDropdown()
    }, [])
    function populateDropdown() {
        fetch('/treatment')
            .then(res => res.json())
            .then(json => {console.log(json); setTreatments(json)})
    }
    return (
        <>
            <Dropdown onSelect={(key) => {console.log(treatments[key]); setSelectedTreatment(treatments[key])}}>
                <Dropdown.Toggle variant='outline-success'>
                    {!selectedTreatment ? 'Behandling' : selectedTreatment.name}
                </Dropdown.Toggle>
                <Dropdown.Menu style={{ width: "100%"}} >
                    {treatments && treatments.map((treatment, index) => <Dropdown.Item  key={index} eventKey={index}>{treatment.name}</Dropdown.Item>)}
                </Dropdown.Menu>
            </Dropdown>
        </>
    )
}