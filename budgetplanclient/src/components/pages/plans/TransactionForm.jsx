import {Button, Form} from "react-bootstrap";
import {useState, useEffect} from "react";

function TransactionForm({ transaction, date, onSave }) {
    const [formData, setFormData] = useState({ id: "", value: 0, description: "", date: date });

    useEffect(() => {
        setFormData(transaction);
    }, [transaction]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData((prevFormData) => ({
            ...prevFormData,
            [name]: value
        }));
    };

    const handleSubmit = () => {
        onSave(formData);
    };

    const handleCancel = () => {
        setFormData({ id: "", value: 0, description: "", date: date});
    };

    return (
        <Form>
            <Form.Group className="mb-3">
                <Form.Label>Wartość</Form.Label>
                <Form.Control
                    type="number"
                    name="value"
                    value={formData.value}
                    onChange={handleChange}
                />
            </Form.Group>
            <Form.Group className="mb-3">
                <Form.Label>Opis</Form.Label>
                <Form.Control
                    type="text"
                    name="description"
                    value={formData.description}
                    onChange={handleChange}
                />
            </Form.Group>
            <Form.Group className="mb-3">
                <Form.Label>Data</Form.Label>
                <Form.Control
                    type="date"
                    name="date"
                    value={formData.date}
                    onChange={handleChange}
                />
            </Form.Group>
            <div className="d-flex justify-content-between">
                <Button variant="primary" onClick={handleSubmit}>
                    {formData.id ? "Aktualizuj" : "Dodaj"}
                </Button>
                {formData.id && (
                    <Button variant="secondary" onClick={handleCancel}>
                        Anuluj
                    </Button>
                )}
            </div>
        </Form>
    );
}

export default TransactionForm;