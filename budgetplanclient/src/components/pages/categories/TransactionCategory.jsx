import './TransactionCategory.css';
import { useEffect, useState } from 'react';
import useTransactionCategoriesApi from "../../../services/api/transactionCategories.jsx";
import CategoryList from './CategoryList';

function TransactionCategory() {
    const {
        getListTransactionCategories,
        addOverTransactionCategory,
        addTransactionCategory
    } = useTransactionCategoriesApi();

    const [budgetPlansTransactionCategories, setBudgetPlansTransactionCategories] = useState([]);

    useEffect(() => {
        const fetchCategories = async () => {
            try {
                const data = await getListTransactionCategories();
                setBudgetPlansTransactionCategories(data.budgetPlanTransactionCategoriesData || []);
            } catch (error) {
                setBudgetPlansTransactionCategories([]);
                console.error('Error fetching transaction categories:', error);
            }
        };

        fetchCategories();
    }, []);

    const handleAddCategory = async (budgetPlanId, categoryName) => {
        try {
            await addOverTransactionCategory({
                BudgetPlanId: budgetPlanId,
                Name: categoryName,
                TransactionType: 0 // Assuming 0 for Income
            });
            // Refresh categories
            const data = await getListTransactionCategories();
            setBudgetPlansTransactionCategories(data.budgetPlanTransactionCategoriesData || []);
        } catch (error) {
            console.error('Error adding transaction category:', error);
        }
    };

    const handleAddSubCategory = async (mainCategoryId, subCategoryName) => {
        try {
            await addTransactionCategory({
                OverTransactionCategoryId: mainCategoryId,
                CategoryName: subCategoryName,
            });
            // Refresh categories
            const data = await getListTransactionCategories();
            setBudgetPlansTransactionCategories(data.budgetPlanTransactionCategoriesData || []);
        } catch (error) {
            console.error('Error adding transaction category:', error);
        }
    };

    return (
        <div className="grid-container">
            <div className="transaction-category-list">
                <h1>Transaction Categories</h1>
                <CategoryList
                    categories={budgetPlansTransactionCategories}
                    onAddCategory={handleAddCategory}
                    onAddSubCategory={handleAddSubCategory}
                />
            </div>
        </div>
    );
}

export default TransactionCategory;