import {Modal, Button} from 'react-bootstrap';
import {useState} from "react";

const BudgetPlanCreateModal = ({show, handleClose, createBudgetPlan}) => {
    const [name, setName] = useState('');

    const handleSubmit = async (event) => {
        event.preventDefault();
        createBudgetPlan(
            {
                name: name
            });
        setName('');
        handleClose();
    }

    return (
        <Modal show={show} onHide={handleClose}>
            <form onSubmit={handleSubmit}>
                <Modal.Header closeButton>
                    <Modal.Title>Utwórz budżet plan</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <div className="form-group">
                        <label htmlFor="name">Nazwa</label>
                        <input type="text" className="form-control" id="name" placeholder="Wprowadź nazwę"
                               onChange={(e) => setName(e.target.value)} value={name}/>
                    </div>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Zamknij
                    </Button>
                    <button className={'btn btn-success'} type={"submit"}>
                        Utwórz
                    </button>
                </Modal.Footer>
            </form>
        </Modal>
    );
}

export default BudgetPlanCreateModal;