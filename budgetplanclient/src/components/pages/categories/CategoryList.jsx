import PropTypes from 'prop-types';
import SubCategoryList from './SubCategoryList';
import AddCategoryForm from './AddCategoryForm';

const CategoryList = ({ categories, onAddCategory, onAddSubCategory }) => {
    return (
        <ul>
            {categories.map(budgetPlan => (
                <li key={budgetPlan.budgetPlanId}>
                    {budgetPlan.budgetPlanName}
                    <ul>
                        {budgetPlan.overTransactionCategoryList.map(category => (
                            <li key={category.id}>
                                {category.transactionCategoryName}
                                <SubCategoryList
                                    subCategories={category.transactionCategoryDtos}
                                    mainCategorxyId={category.id}
                                    onAddSubCategory={onAddSubCategory}
                                />
                            </li>
                        ))}
                        <li>
                            <AddCategoryForm onAddCategory={(categoryName) => onAddCategory(budgetPlan.budgetPlanId, categoryName)} />
                        </li>
                    </ul>
                </li>
            ))}
        </ul>
    );
};

CategoryList.propTypes = {
    categories: PropTypes.arrayOf(PropTypes.shape({
        budgetPlanId: PropTypes.number.isRequired,
        budgetPlanName: PropTypes.string.isRequired,
        overTransactionCategoryList: PropTypes.arrayOf(PropTypes.shape({
            id: PropTypes.number.isRequired,
            transactionCategoryName: PropTypes.string.isRequired,
            transactionCategoryDtos: PropTypes.arrayOf(PropTypes.shape({
                id: PropTypes.number.isRequired,
                transactionCategoryName: PropTypes.string.isRequired
            })).isRequired
        })).isRequired
    })).isRequired,
    onAddCategory: PropTypes.func.isRequired,
    onAddSubCategory: PropTypes.func.isRequired,
};

export default CategoryList;