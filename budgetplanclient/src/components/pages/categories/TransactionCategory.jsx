import './TransactionCategory.css';
import { useEffect, useState } from 'react';
import {useParams} from "react-router-dom";
import useBudgetPlansApi from "../../../services/api/budgetPlans.jsx";
import SubCategoryList from "./SubCategoryList.jsx";
import AddCategoryForm from "./AddCategoryForm.jsx";

function TransactionCategory() {
    const {budgetPlanId} = useParams();
    const {getTransactionCategoriesForBudget} = useBudgetPlansApi();

    const [budgetPlanTransactionCategories, setBudgetPlanTransactionCategories] = useState([]);
    const [action, setAction] = useState(false);



    useEffect(() => {
        const fetchCategories = async () => {
            try {
                const data = await getTransactionCategoriesForBudget(budgetPlanId);
                console.log(data);

                setBudgetPlanTransactionCategories(data.transactionCategoryDtos || []);
            } catch (error) {
                setBudgetPlanTransactionCategories([]);
                console.error('Error fetching transaction categories:', error);
            }
        };

        fetchCategories();

        if (action) {
            setAction(false);
        }
    }, [action]);

    const handleAction = () =>{
        setAction(true);
    };

    return (
        <div className="grid-container">
            <div className="transaction-category-list">
                <ul>
                    {budgetPlanTransactionCategories.map(category => (
                        <li key={category.id}>
                            {category.transactionCategoryName}
                            <SubCategoryList
                                subCategories={category.transactionCategoryDtos}
                                mainCategoryId={category.id}
                                handleAction={handleAction}
                            />
                        </li>
                    ))}
                    <li>
                        <AddCategoryForm budgetPlanId={budgetPlanId} handleAction={handleAction}/>
                    </li>
                </ul>
            </div>
        </div>
    );
}

export default TransactionCategory;