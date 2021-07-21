import re

import nltk
import pandas as pd
import pickle
import sys
from nltk.corpus import stopwords
from nltk.tokenize import RegexpTokenizer
from sklearn.metrics.pairwise import cosine_similarity

if len(sys.argv) != 2:
    print("ERROR: the script must have two arguments")
    exit(1)

nltk.download('stopwords')


def remove_non_ascii(text):
    return "".join(character for character in text if ord(character) < 128)


def make_lower_case(text):
    return text.lower()


def remove_stop_words(text):
    text = text.split()
    stops = set(stopwords.words("english"))
    text = [word for word in text if not word in stops]
    text = " ".join(text)
    return text


def remove_punctuation(text):
    tokenizer = RegexpTokenizer(r'\w+')
    text = tokenizer.tokenize(text)
    text = " ".join(text)
    return text


def remove_html(text):
    html_pattern = re.compile('<.*?>')
    return html_pattern.sub(r'', text)


df = pd.read_csv("data.csv")

df['cleaned'] = df['description'].apply(remove_non_ascii)

df['cleaned'] = df.cleaned.apply(func=make_lower_case)
df['cleaned'] = df.cleaned.apply(func=remove_stop_words)
df['cleaned'] = df.cleaned.apply(func=remove_punctuation)
df['cleaned'] = df.cleaned.apply(func=remove_html)

filename = 'trained_word2vec_model.sav'
google_model = pickle.load(open(filename, 'rb'))


def calculate_embeddings():
    
    global word_embeddings
    word_embeddings = []
 
    for line in df['cleaned']:
        average_wv = None
        count = 0
        for word in line.split():
            if word in google_model.wv.vocab:
                count += 1
                if average_wv is None:
                    average_wv = google_model.wv[word]
                else:
                    average_wv = average_wv + google_model.wv[word]
                
        if average_wv is not None:
            average_wv = average_wv / count
        
            word_embeddings.append(average_wv)


def get_recommendations(title):
    
    calculate_embeddings()
    cosine_similarities = cosine_similarity(word_embeddings, word_embeddings)

    books = df[['description', 'title']]

    indices = pd.Series(df.index, index=df['title']).drop_duplicates()
         
    idx = indices[title]
    sim_scores = list(enumerate(cosine_similarities[idx]))
    sim_scores = sorted(sim_scores, key=lambda x: x[1], reverse=True)
    sim_scores = sim_scores[1:6]
    book_indices = [i[0] for i in sim_scores]
    recommend = books.iloc[book_indices]
    for index, row in recommend.iterrows():
        print(row['title'])


get_recommendations(sys.argv[1])
