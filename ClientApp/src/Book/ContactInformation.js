import { Form, Button } from "react-bootstrap"

const ContactInformation = ({ setContactInformation, contactInformation }) => {



    return (
        <>
            <Form>
                <Form.Group className="mb-3" controlId="formBasicEmail">
                    <Form.Control onChange={(e) => setContactInformation({...contactInformation, name: e.target.value})} type="text" placeholder="Namn" />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Control onChange={(e) => setContactInformation({...contactInformation, phone: e.target.value})} type="tel" placeholder="Telefonnummer" />
                </Form.Group>
            </Form>
        </>
    )
}
export { ContactInformation }