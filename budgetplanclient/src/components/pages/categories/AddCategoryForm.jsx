import { useState } from 'react';
import PropTypes from 'prop-types';
import useTransactionCategoriesApi from "../../../services/api/transactionCategories.jsx";

const AddCategoryForm = ({ budgetPlanId, handleAction }) => {
    const { addOverTransactionCategory } = useTransactionCategoriesApi();

    const [categoryName, setCategoryName] = useState('');
    const [transactionType, setTransactionType] = useState(0);
    const thisBudgetPlanId = budgetPlanId;

    const handleAddCategory = async (event) => {
        try {
            event.preventDefault();
            await addOverTransactionCategory({
                BudgetPlanId: thisBudgetPlanId,
                Name: categoryName,
                TransactionType: transactionType
            });
            handleAction();
            setCategoryName('');
        } catch (error) {
            console.error('Error adding transaction category:', error);
        }
    };

    return (
        <form onSubmit={handleAddCategory}>
            <input type="text" placeholder="Add category" value={categoryName}
                   onChange={(e) => setCategoryName(e.target.value)}
            />
            <select value={transactionType} onChange={(e) => setTransactionType(Number(e.target.value))}>
                <option value={0}>Wpływy</option>
                <option value={1}>Wydatki</option>
            </select>
            <button type="submit">Add</button>
        </form>
    );
};

AddCategoryForm.propTypes = {
    budgetPlanId: PropTypes.string.isRequired,
    handleAction: PropTypes.func.isRequired
};

export default AddCategoryForm;