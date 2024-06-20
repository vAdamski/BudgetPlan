import './TransactionCategory.css'
import useTransactionCategoriesApi from "../../../services/api/transactionCategories.jsx";
import {useEffect, useState} from "react";

function TransactionCategory() {

    const {
        getListTransactionCategories,
        addOverTransactionCategory,
        addTransactionCategory,
        deleteTransactionCategory
    } = useTransactionCategoriesApi();

    const [budgetPlansTransactionCategories, setBudgetPlansTransactionCategories] = useState([]);
    const [newCategoryName, setNewCategoryName] = useState('');
    const [newSubCategoryName, setNewSubCategoryName] = useState('');

    useEffect(() => {
        const fetchCategories = async () => {
            try {
                const data = await getListTransactionCategories();
                setBudgetPlansTransactionCategories(data.budgetPlanTransactionCategoriesData || []);
            } catch (error) {
                setBudgetPlansTransactionCategories([])
                console.error('Error fetching transaction categories:', error);
            }
        };

        fetchCategories();
    }, []);

    const handleAddCategory = async (budgetPlanId) => {
        try {
            await addOverTransactionCategory({
                BudgetPlanId: budgetPlanId,
                Name: newCategoryName,
                TransactionType: 0 // Assuming 0 for Income
            });
            setNewCategoryName(''); // Reset input
            // Refresh categories
            const data = await getListTransactionCategories();
            setBudgetPlansTransactionCategories(data.budgetPlanTransactionCategoriesData || []);
        } catch (error) {
            console.error('Error adding transaction category:', error);
        }
    };

    const handleAddSubCategory = async (mainCategoryId) => {
        try {
            await addTransactionCategory({
                OverTransactionCategoryId: mainCategoryId,
                CategoryName: newSubCategoryName,
            });
            setNewSubCategoryName(''); // Reset input

            // Refresh categories
            const data = await getListTransactionCategories();
            setBudgetPlansTransactionCategories(data.budgetPlanTransactionCategoriesData || []);
        } catch (error) {
            console.error('Error adding transaction category:', error);
        }
    };


    return (
        <div className={'grid-container'}>
            <div className={'transaction-category-list'}>
                <h1>Transaction Categories</h1>
                <ul>
                    {budgetPlansTransactionCategories.map(budgetPlan => (
                        <li key={budgetPlan.budgetPlanId}>
                            {budgetPlan.budgetPlanName}
                            <ul>
                                {budgetPlan.overTransactionCategoryList.map(category => (
                                    <li key={category.id}>
                                        {category.transactionCategoryName}
                                        <ul>
                                            {category.transactionCategoryDtos.map(subCategory => (
                                                <li key={subCategory.id}>
                                                    {subCategory.transactionCategoryName}
                                                </li>
                                            ))}
                                            <li>
                                                <form onSubmit={(e) => {
                                                    e.preventDefault();
                                                    handleAddSubCategory(category.id);
                                                }}>
                                                    <input type={'text'} placeholder={'Add category'}
                                                           value={newSubCategoryName}
                                                           onChange={(e) => setNewSubCategoryName(e.target.value)}/>
                                                    <button type='submit'>Add</button>
                                                </form>
                                            </li>
                                        </ul>
                                    </li>
                                ))}
                                <li>
                                    <form onSubmit={(e) => {
                                        e.preventDefault();
                                        handleAddCategory(budgetPlan.budgetPlanId);
                                    }}>
                                        <input type={'text'} placeholder={'Add category'} value={newCategoryName}
                                               onChange={(e) => setNewCategoryName(e.target.value)}/>
                                        <button type='submit'>Add</button>
                                    </form>
                                </li>
                            </ul>
                        </li>
                    ))}
                </ul>
            </div>
        </div>
    );
}

export default TransactionCategory;