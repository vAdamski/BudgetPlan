import {useEffect, useState} from 'react';
import PropTypes from "prop-types";
import useBudgetPlansApi from "../../../services/api/budgetPlans.jsx";
import useTransactionDetailsApi from "../../../services/api/transactionDetails.jsx";
import {Card, Form, InputGroup} from "react-bootstrap";

function CreateTransactionDetails({budgetPlanId}) {
    const thisBudgetPlanId = budgetPlanId;

    const getTodayDate = () => {
        const today = new Date();
        const year = today.getFullYear();
        const month = String(today.getMonth() + 1).padStart(2, '0'); // Months are zero-based
        const day = String(today.getDate()).padStart(2, '0');
        return `${year}-${month}-${day}`;
    };

    const {getTransactionCategoriesForBudget} = useBudgetPlansApi();
    const {createTransactionDetails} = useTransactionDetailsApi();

    const [transactionValue, setTransactionValue] = useState(0.0);
    const [transactionDescription, setTransactionDescription] = useState('');
    const [transactionCategoryId, setTransactionCategoryId] = useState('');
    const [transactionDate, setTransactionDate] = useState(getTodayDate);

    const [subTransactionCategories, setSubTransactionCategories] = useState([]);

    useEffect(() => {
        const fetchSubTransactionCategories = async () => {
            const data = await getTransactionCategoriesForBudget(thisBudgetPlanId);
            setSubTransactionCategories(data.transactionCategoryDtos || []);
        }

        fetchSubTransactionCategories();
    }, []);

    const handleSubmit = async (e) => {
        e.preventDefault();

        await createTransactionDetails({
            TransactionCategoryId: transactionCategoryId,
            value: transactionValue,
            description: transactionDescription,
            date: transactionDate,
        });
    };

    return (
        <Card>
            <Card.Header className={'text-start'} style={{backgroundColor: '#111111'}}>
                <a style={{color: '#ffffff'}}>Transakcje</a>
            </Card.Header>
            <Card.Body>
                <Form onSubmit={handleSubmit}>
                    <InputGroup className="mb-3">
                        <InputGroup.Text>Wartość:</InputGroup.Text>
                        <Form.Control type="number" value={transactionValue} onChange={e => setTransactionValue(e.target.value)} id={''}/>
                    </InputGroup>

                    <InputGroup className="mb-3">
                        <InputGroup.Text>Kategoria:</InputGroup.Text>
                        <Form.Select variant="outline-secondary" title="Kategoria" id={'categoryType'} value={transactionCategoryId}
                                     onChange={e => setTransactionCategoryId(e.target.value)}>
                            {subTransactionCategories.map(category => (
                                <optgroup key={category.id} label={category.transactionCategoryName}>
                                    {category.transactionCategoryDtos.map(subCategory => (
                                        <option key={subCategory.id}
                                                value={subCategory.id}>{subCategory.transactionCategoryName}</option>
                                    ))}
                                </optgroup>
                            ))}
                        </Form.Select>
                    </InputGroup>

                    <InputGroup className="mb-3">
                        <InputGroup.Text>Opis:</InputGroup.Text>
                        <Form.Control type="number" value={transactionDescription} onChange={e => setTransactionDescription(e.target.value)} id={''}/>
                    </InputGroup>

                    <InputGroup className="mb-3">
                        <InputGroup.Text>Data:</InputGroup.Text>
                        <Form.Control type="date" value={transactionDate} onChange={e => setTransactionDate(e.target.value)} id={''}/>
                    </InputGroup>

                    <input className={'btn btn-success'} type="submit" value="Dodaj"/>
                </Form>
            </Card.Body>
        </Card>
    );
}

CreateTransactionDetails.propTypes = {
    budgetPlanId: PropTypes.string.isRequired
};

export default CreateTransactionDetails;