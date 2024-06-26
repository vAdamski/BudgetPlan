import {useEffect, useState} from 'react';
import PropTypes from "prop-types";
import useBudgetPlansApi from "../../../services/api/budgetPlans.jsx";
import useTransactionDetailsApi from "../../../services/api/transactionDetails.jsx";
import {Card, Form} from "react-bootstrap";

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
        createTransactionDetails({
            TransactionCategoryId: transactionCategoryId,
            value: transactionValue,
            description: transactionDescription,
            date: transactionDate,
        });
    };

    return (
        <Card>
            <Card.Header>
                <a>Transakcje</a>
            </Card.Header>
            <Card.Body>
                <Form onSubmit={handleSubmit}>
                    <label htmlFor={'value'}>Wartość:</label>
                    <input id={'value'}
                           value={transactionValue}
                           onChange={e => setTransactionValue(e.target.value)}
                           type={'number'}
                           placeholder={'0.00'}
                           required
                    />

                    <label>Kategoria:</label>
                    <select value={transactionCategoryId}
                            onChange={e => setTransactionCategoryId(e.target.value)}
                            required
                    >
                        {subTransactionCategories.map(category => (
                            <optgroup key={category.id} label={category.transactionCategoryName}>
                                {category.transactionCategoryDtos.map(subCategory => (
                                    <option key={subCategory.id}
                                            value={subCategory.id}>{subCategory.transactionCategoryName}</option>
                                ))}
                            </optgroup>
                        ))}
                    </select>

                    <label htmlFor={'description'}>Opis:</label>
                    <input id={'description'}
                           value={transactionDescription}
                           onChange={e => setTransactionDescription(e.target.value)}
                           type={'text'}
                           placeholder={'Opis'}
                    />

                    <label>Data:</label>
                    <input value={transactionDate}
                           onChange={e => setTransactionDate(e.target.value)}
                           type={'date'}
                           required
                    />

                    <input type="submit" value="Submit"/>
                </Form>
            </Card.Body>
        </Card>
    );
}

CreateTransactionDetails.propTypes = {
    budgetPlanId: PropTypes.string.isRequired
};

export default CreateTransactionDetails;