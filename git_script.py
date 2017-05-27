import os

gitAdd = 'git add .'
gitCommit = 'git commit -m'

def gitUpdate():
    comment = raw_input("Give your comment: ")
    os.system(gitAdd)
    print 'Finish ', gitAdd

    os.system(gitCommit+'\"'+comment+'\"')
    print 'Finish', gitCommit+'\"'+comment+'\"'

if __name__ == '__main__':
    gitUpdate()